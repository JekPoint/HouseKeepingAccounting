import React from 'react'
import './House.css'

const house = (props) =>{
    return(
        <div className="House">
            <p>City name: {props.cityName}</p>    
            <p>Street name: {props.streetName}</p>
            <p>Home number: {props.homeNumber}</p>         
            <p>{props.children}</p>   
            <input type="text" onChange={props.changed} value={props.cityName}/>
        </div>
    )
};

export default house;