import React from 'react';
import './home.scss';


const Home = () => {
    return <div className="home">
        <p className="title">Todo list</p>
        <p className="subtitle">Write your todos to make a progress in your life</p>
        <div className="btn-group">
            <a className="btn" href="/login">Login</a>
            <a className="btn" href="/signup">Sign up</a>
        </div>
    </div>;
};

export default Home;