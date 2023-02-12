import React, {useState} from 'react';
import { useAppDispatch } from '../../store';
import { setupToken } from '../../slices/userSlice';
import {signIn} from '../../api/users';
import './login.scss';

const Login = () => {
    const [email, setEmail] = useState<string>('');
    const [password, setPassword] = useState<string>('');
    const dispatch = useAppDispatch();
    const signInAndRedirect = async () => {
        const result = await signIn(email, password);
        if(result.data && result.data.token) {
            dispatch(setupToken(result.data.token));
            window.location.replace("/todo");
            return;
        }
        alert(result.data);
    };
    return <div className="login">
        <div className="modal">
            <p className="title">Sign in</p>
            <div className="form">
                <div className="input-wrapper">
                    <label htmlFor="email">email</label>
                    <input type="email" id="email" placeholder='please enter email' value={email} onChange={ev => setEmail(ev.target.value)} />
                </div>
                
                <div className="input-wrapper">
                    <label htmlFor="password">password</label>
                    <input type="password" id="password" placeholder='please enter password' value={password} onChange={ev => setPassword(ev.target.value)}  />
                </div>

                <button onClick={signInAndRedirect}>Login</button>
            </div>

            <div className="signup-text">Don't have an account? Please <a href="/signup"> sign up</a></div>
        </div>
    </div>;
};

export default Login;