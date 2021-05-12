import React, { useEffect, useState } from "react";
import 'antd/dist/antd.css';
import './add-user.style.css'
import { Form, Button, Select } from 'antd';

export const ExportRoom = () => {
    const [rooms, setRoom] = useState(null);
    const axios = require("axios");
    const onFinish = (values) => {
        axios
            .get("/room/{values.roomID}")
            //új oldalra json formátumban :c
    };


    useEffect(() => {

        const minTime2 = new Promise((resolve) => setTimeout(resolve, 300));
        const req2 = axios.get(`/room`);

        Promise.all([minTime2, req2]).then((values) => {
            const reqData2 = values[1];
            console.log(reqData2.data);
            setRoom(reqData2.data);
        }
        );
    }, [axios, setRoom]);


    return (
        <>
            <div className="logo-login">ChatFlow</div>
            <div className='form-container'>
                <div className='form-container2'>
                    <Form onFinish={onFinish}>                        
                        <Form.Item label="Select Room">
                            <Select>
                                {rooms?.map(room => (
                                    <Select.Option value={room.roomID}>{room.roomName}</Select.Option>
                                ))}
                            </Select>
                        </Form.Item>
                        <Form.Item>
                            <Button type="primary" htmlType="submit" className='add-form-button'>Export Room</Button>
                            <Button className='add-form-button' href = '/admin'>Back to Admin UI</Button>
                        </Form.Item>
                    </Form>
                </div>
            </div>
        </>
    );
};
