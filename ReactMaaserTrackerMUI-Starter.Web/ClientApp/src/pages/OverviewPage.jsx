import React, { useEffect, useState } from 'react';
import { Container, Typography, Box, Paper } from '@mui/material';
import axios from 'axios';

const OverviewPage = () => {

    const [totalIncome, setTotalIncome] = useState('');
    const [totalMaaser, setTotalMaaser] = useState('');
    const [maaserObligated, setMaaserObligated] = useState('');
    const [remainingObligation, setRemainingObligation] = useState('');

    useEffect(() => {
        const setState = async () => {
            const { data } = await axios.get('/api/maaser/gettotalincome')
            setTotalIncome(data);
            const maaserAmount = data / 10;
            setMaaserObligated(maaserAmount);
            const { data: maaser } = await axios.get('/api/maaser/gettotalmaaser')
            setTotalMaaser(maaser);
            setRemainingObligation(maaserAmount > maaser? maaserAmount - maaser : 0);
        }
        setState();
    }, [])


    return (
        <Container
            maxWidth="md"
            sx={{
                display: 'flex',
                flexDirection: 'column',
                justifyContent: 'center',
                alignItems: 'center',
                height: '80vh',
                textAlign: 'center'
            }}
        >
            <Paper elevation={3} sx={{ padding: '120px', borderRadius: '15px' }}>
                <Typography variant="h2" gutterBottom>
                    Overview
                </Typography>
                <Box sx={{ marginBottom: '20px' }}>
                    <Typography variant="h5" gutterBottom>
                        Total Income: ${totalIncome}
                    </Typography>
                    <Typography variant="h5" gutterBottom>
                        Total Maaser: ${totalMaaser }
                    </Typography>
                </Box>
                <Box>
                    <Typography variant="h5" gutterBottom>
                        Maaser Obligated: ${maaserObligated}
                    </Typography>
                    <Typography variant="h5" gutterBottom>
                        Remaining Maaser obligation: ${remainingObligation }
                    </Typography>
                </Box>
            </Paper>
        </Container>
    );
}

export default OverviewPage;
