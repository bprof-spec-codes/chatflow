import React from 'react';
import './card.styles.css'

import { Button } from 'antd';
import { DeleteOutlined } from '@ant-design/icons';

export const Card = props => (
    
    <div className='card-container'>
        <div className='avatar'>
            <img
                alt='avatar'
                src={`https://robohash.org/${props.member.id}?set=set3&size=200x200`}>
            </img>
        </div>
        <div className='personal-data'>
            <h2>{props.member.userName}</h2>
            <p>{props.member.email}</p>
        </div>
        <div className='tools'>
            <Button shape='round' icon={<DeleteOutlined />}></Button>
        </div>
    </div>


)