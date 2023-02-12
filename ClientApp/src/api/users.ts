import axios from 'axios';

export const signUp = async (email: string, password: string, name: string) => {
    const result = await axios.post('https://localhost:7102/api/auth/register', {
        email,
        password,
        name
    },
    {headers: {
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Headers': '*',
        'Access-Control-Allow-Credentials': 'true'
    }});
    return result;
};

export const signIn = async (email: string, password: string) => {
    const result = await axios.post('https://localhost:7102/api/auth/login', {
        email,
        password
    });
    return result;
};