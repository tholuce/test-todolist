import React, {useState} from 'react';
import {signUp} from '../../api/users';
import './signup.scss';

const Signup = () => {
    const [name, setName] = useState<string>('');
    const [email, setEmail] = useState<string>('');
    const [password, setPassword] = useState<string>('');

    const signUpAndRedirect = async () => {

        const result = await signUp(email, password, name);
        if(result.data === "success") {
            window.location.replace("/login");
            return;
        }

        alert(result.data);
    };
    return <div className="signup">
        <p className="title">Signup</p>
        <div className="form">
            <div className="input-wrapper">
                <label htmlFor="name">Name</label>
                <input id="name" type="text" placeholder='enter your name' onChange={(ev) => {setName(ev.target.value)}} value={name} />
            </div>

            <div className="input-wrapper">
                <label htmlFor="email">Email</label>
                <input id="email" type="email" placeholder='enter your email' onChange={(ev) => {setEmail(ev.target.value)}} value={email} />
            </div>

            <div className="input-wrapper">
                <label htmlFor="password">Password</label>
                <input id="password" type="password" placeholder='enter your password' onChange={(ev) => {setPassword(ev.target.value)}} value={password} />
            </div>

            <button type="submit" onClick={signUpAndRedirect}>Signup</button>
        </div>
        <p className="login-text">Already signed up? Please <a href="/login">login</a></p>
    </div>;
};

export default Signup;