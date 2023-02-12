import {combineReducers, configureStore} from '@reduxjs/toolkit';
import { useDispatch, useSelector, TypedUseSelectorHook } from 'react-redux';
import todoReducer from './slices/todoSlice';
import userReducer from './slices/userSlice';

export const store = configureStore({reducer: combineReducers({user: userReducer, todo: todoReducer}), devTools: process.env.NODE_ENV !== 'production', preloadedState: {
    user: {
        token: localStorage.getItem('token') || '',
    }
}});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export const useAppDispatch: () => AppDispatch = useDispatch;
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;