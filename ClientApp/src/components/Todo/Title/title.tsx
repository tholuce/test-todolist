import React, { useState, useEffect} from 'react';
import './title.scss';

enum TitleTexts {
    'Todo',
    'Done'
};

const Title = () => {
    const [isCompleted, setCompleted] = useState<boolean>(false);
    const [text, setText] = useState<TitleTexts>(TitleTexts.Todo);
    useEffect(() => {
        const interval = setInterval(() => {
            setCompleted(!isCompleted);
            setText(!isCompleted ? TitleTexts.Done: TitleTexts.Todo);
        }, 2000.0);
        return () => {
            clearInterval(interval);
        };
    }, [isCompleted, text]);
    return <div className="title">
        <input type="checkbox" checked={isCompleted} />
        <span className="text">{TitleTexts[text]}</span></div>;
};

export default Title;