import React from "react";
import { useAppSelector } from "../../../store";
import Item from "../Item/item";
import './list.scss';

const List = () => {     
    const items = useAppSelector(state => state.todo.items);

    return <div className="todolist">
    <p className="title">Todo list</p>
        <div className="items">
            {items.map(({id, isCompleted, text}) => <Item key={id} id={id} isCompleted={isCompleted} text={text}  />)}
        </div>
    </div>;
};

export default List;