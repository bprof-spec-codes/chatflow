import React from 'react';
import './card-list.style.css';
import { Card } from '../card/card.component';

export const CardList = (props) => (
    <div className='card-list'>
        {props.members.map(member => (
            <Card key={member.id} member={member} />
        ))}
    </div>
);