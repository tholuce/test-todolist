import React from "react";
import { TodoItem } from "../../../interfaces/todoitem";
import { useAppDispatch, useAppSelector } from "../../../store";
import { deleteTodo, completeTodo } from '../../../api/todo';
import { deleteTodoItem, completeTodoItem } from '../../../slices/todoSlice';
import './item.scss';

const Item = ({id, isCompleted, text}: TodoItem) => {
    const dispatch = useAppDispatch();
    const token = useAppSelector(state => state.user.token);

    const deleteButtonClick = async () => {
        const result = await deleteTodo(token, id);
        if(!result || result.status !==200) {
            return;
        }
        dispatch(deleteTodoItem(id));
    };

    const completeButtonClick = async () => {
        const result = await completeTodo(token, id);
        if(!result || result.status !==200) {
            return;
        }
        dispatch(completeTodoItem({id, isCompleted: true, text}));
    };
    return <div className="todoitem">
        <p className={`text ${isCompleted && 'text-line'}`}>{text}</p>
        <div className="btn-group">
            {!isCompleted && <button className="btn" onClick={completeButtonClick}>Complete</button>}
            <button className="btn" onClick={deleteButtonClick}>Delete</button>
        </div>
    </div>; 
};

export default Item;