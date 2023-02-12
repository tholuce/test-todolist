import {createSlice, PayloadAction} from '@reduxjs/toolkit';
import { TodoItem } from '../interfaces/todoitem';

interface TodoState {
    items: TodoItem[];
}

const initialState: TodoState = {
    items: []
};

const todoSlice = createSlice({
    name: 'todo',
    initialState,
    reducers: {
        deleteTodoItem: (state: TodoState, {payload}: PayloadAction<string>) => {
            state.items = state.items.filter(el => el.id !== payload);
        },
        addTodoItems: (state: TodoState, {payload}: PayloadAction<TodoItem[]>) => {
            state.items = payload;
        },
        completeTodoItem: (state, {payload}: PayloadAction<TodoItem>) => {
            const index = state.items.findIndex(el => el.id === payload.id);
            if(index < 0) {
                return;
            }
            state.items[index].isCompleted = payload.isCompleted;
        }
    },
});

export const {addTodoItems, deleteTodoItem, completeTodoItem} = todoSlice.actions;

export default todoSlice.reducer;