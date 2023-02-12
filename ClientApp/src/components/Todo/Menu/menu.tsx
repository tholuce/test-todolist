import React from "react";
import { setupToken } from '../../../slices/userSlice';
import { useAppDispatch } from "../../../store";
import Title from "../Title/title";
import "./menu.scss";

const Menu = () => {
    const dispatch = useAppDispatch();
    
    const logoutButtonClick = () => {
        dispatch(setupToken(''));
        window.location.replace('/login');
    };

    return <div className="menu">
        <ul>
            <li><Title /></li>
            <li className="right"><div onClick={logoutButtonClick}>logout</div></li>
        </ul>
    </div>;
};

export default Menu;