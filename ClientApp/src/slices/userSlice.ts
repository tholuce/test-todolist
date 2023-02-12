import {createSlice, PayloadAction} from '@reduxjs/toolkit';

interface UserState {
    token: string;
}

const initialState: UserState = {
    token: ''
};

const userSlice = createSlice({
    name: 'todo',
    initialState,
    reducers: {
        setupToken: (state: UserState, {payload}: PayloadAction<string>) => {
            if(payload === '')
            {
                state.token = payload;
                localStorage.removeItem('token');
                return;        
            }
            state.token = payload;
            localStorage.setItem('token', payload);
        }
    },
});

export const {setupToken} = userSlice.actions;

export default userSlice.reducer;