import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { Container, TextField, Button, Autocomplete, Typography } from '@mui/material';
import dayjs from 'dayjs';
import axios from 'axios';



const AddIncomePage = () => {
    const [selectedDate, setSelectedDate] = useState(new Date());
    const [source, setSource] = useState(null);
    const [amount, setAmount] = useState('');
    const [sources, setSources] = useState([]);
    const navigate = useNavigate();

    const onAddClick = async () => {
        const { data } = await axios.get(`/api/maaser/getsourceforstring?source=${source.sourceName}`)
        const income = {
            amount,
            sourceId: data.id,
            date: selectedDate
        }
        await axios.post('/api/maaser/addincome', income)
        navigate('/income');
    }

    useEffect(() => {
        const getSources = async () => {
            const { data } = await axios.get('/api/maaser/getsources');
            setSources(data);
        }
        getSources();
    },
        [])


    return (
        <Container maxWidth="sm" sx={{ display: 'flex', flexDirection: 'column', justifyContent: 'center', height: '80vh' }}>
            <Typography variant="h2" component="h1" gutterBottom>
                Add Income
            </Typography>
            <Autocomplete
                options={sources}
                getOptionLabel={(option) => option.sourceName}
                fullWidth
                margin="normal"
                renderInput={(params) => <TextField {...params} label="Source" variant="outlined" />}
                onChange={(e, value) => { setSource(value); }}
                value={source}
            />
            <TextField
                label="Amount"
                variant="outlined"
                type="number"
                onChange={(event) => setAmount(event.target.value)}
                value={amount}
                InputProps={{ inputProps: { min: 0, step: 0.01 } }}
                fullWidth
                margin="normal"
            />
            <TextField
                label="Date"
                type="date"
                value={dayjs(selectedDate).format('YYYY-MM-DD')}
                onChange={e => setSelectedDate(e.target.value)}
                renderInput={(params) => <TextField {...params} fullWidth margin="normal" variant="outlined" />}
            />
            <Button variant="contained" color="primary" onClick={onAddClick}>Add Income</Button>
        </Container>
    );
}

export default AddIncomePage;
