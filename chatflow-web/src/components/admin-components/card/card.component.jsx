import React from 'react';
import './card.styles.css'

export const Card = props => (
    <div className='card-container'>
        <img
            alt='monster'
            src={`https://robohash.org/${props.member.id}?set=set3&size=180x180`}>
        </img>
        <h2>{props.member.name}</h2>
        <p>{props.member.email}</p>
    </div>

)