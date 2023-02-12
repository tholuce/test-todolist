import React, {useEffect} from 'react';
import ItemCreator from '../../components/Todo/ItemCreator/itemcreator';
import List from '../../components/Todo/List/list';
import Menu from '../../components/Todo/Menu/menu';
import { useAppDispatch, useAppSelector } from '../../store';
import { getTodos } from '../../api/todo';
import { addTodoItems } from '../../slices/todoSlice';
import { Navigate } from 'react-router-dom';


const Todo = () => {
    const token = useAppSelector(state => state.user.token);
    const dispatch = useAppDispatch();

    useEffect( () => {
        getTodos(token)
        .then(response => {
            if(!response || response.status !== 200) {
                return;
            }
            dispatch(addTodoItems(response.data));
        });
    });

    if(!token) {
        return <Navigate to="/" replace />;
    }
    
    return <>
    <Menu />
    <ItemCreator />
    <List />
    </>;
};

export default Todo;