import React from 'react';
import { Container, TextField, Button, Typography } from '@mui/material';
import dayjs from 'dayjs';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const AddMaaserPage =() => {
    const [selectedDate, setSelectedDate] = React.useState(new Date());
    const [recipient, setRecipient] = React.useState('');
    const [amount, setAmount] = React.useState('');
    const navigate = useNavigate();

    const onSubmit = async () => {
        const maaser = {
            recipient,
            amount,
            date: selectedDate
        };
        await axios.post('/api/maaser/addmaaser', maaser)
        navigate('/maaser')
    }

    return (
        <Container maxWidth="sm" sx={{ display: 'flex', flexDirection: 'column', justifyContent: 'center', height: '80vh' }}>
            <Typography variant="h2" component="h1" gutterBottom>
                Add Maaser
            </Typography>
            <TextField label="Recipient" variant="outlined" value={recipient} onChange={e => setRecipient(e.target.value)} fullWidth margin="normal" />
            <TextField label="Amount" variant="outlined" value={amount} onChange={e => setAmount(e.target.value)} fullWidth margin="normal" />
            <TextField
                label="Date"
                type="date"
                value={dayjs(selectedDate).format('YYYY-MM-DD')}
                onChange={e => setSelectedDate(e.target.value)}
                renderInput={(params) => <TextField {...params} fullWidth margin="normal" variant="outlined" />}
            />
            <Button variant="contained" color="primary" onClick={onSubmit }>Add Maaser</Button>
        </Container>
    );
}

export default AddMaaserPage;
