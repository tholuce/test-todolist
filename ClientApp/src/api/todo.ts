import axios from 'axios';

export const getTodos = async (token: string) => {
    return await axios.get('https://localhost:7102/api/todo', {
        headers: {
            "Authorization": `Bearer ${token}`
    }})
};

export const addTodo = async (token: string, text: string) => {
    return await axios.post('https://localhost:7102/api/todo', {
        text,
    }, {
        headers: {
            "Authorization": `Bearer ${token}`
    }})

};

export const deleteTodo = async (token: string, id: string) => {
    return await axios.delete(`https://localhost:7102/api/todo/${id}`, {
        headers: {
            "Authorization": `Bearer ${token}`
    }})
};

export const completeTodo = async (token: string, id: string) => {
    return await axios.patch(`https://localhost:7102/api/todo/${id}`, {
        headers: {
            "Authorization": `Bearer ${token}`
    }})
};