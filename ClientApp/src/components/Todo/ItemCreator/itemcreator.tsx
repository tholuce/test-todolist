import React, { useState } from 'react';
import { addTodo, getTodos } from '../../../api/todo';
import { useAppSelector, useAppDispatch } from '../../../store';
import { addTodoItems } from '../../../slices/todoSlice';
import './itemcreator.scss';

const ItemCreator = () => {
    const token: string = useAppSelector<string>(state => state.user.token);
    const [text, setText] = useState<string>('');
    const dispatch = useAppDispatch();
    const onAddTodo = async () => {
        await addTodo(token, text);
        const result = await getTodos(token);
        if(result && result.status === 200 && result.data) {
            dispatch(addTodoItems(result.data));
        }
        setText('');
    };
    return <div className="itemcreator">
        <p className="title">Add todo</p>
        <div className="input-group">
            <input type="text" placeholder="Please type new todo item" onChange={(ev) => setText(ev.target.value)} value={text}/>
            <button className="btn-add" onClick={onAddTodo}>Add</button>
        </div>
    </div>;
};

export default ItemCreator;