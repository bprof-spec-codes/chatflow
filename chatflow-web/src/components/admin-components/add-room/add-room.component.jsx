import React from "react";
import 'antd/dist/antd.css';
import './add-room.style.css'
import { Form, Button, Input } from 'antd';

export const AddRoom = () => {
    const axios = require("axios");
    const onFinish = (values) => {
        axios
            .post("/room", {
                roomID: values.roomID,
                roomName: values.roomName
            })
    };

    return (
        <>
            <div className="logo-login">ChatFlow</div>
            <div className='form-container'>
                <div className='form-container2'>
                    <Form onFinish={onFinish}>
                        <Form.Item name="roomID" rules={[{ required: true, message: "Please input new room's ID!", },]}>
                            <Input
                                className="form-item"
                                placeholder="Room ID"
                            />
                        </Form.Item>
                        <Form.Item name="roomName" rules={[{ required: true, message: "Please input new room's name!", },]}>
                            <Input
                                className="form-item"
                                placeholder="Room name"
                            />
                        </Form.Item>
                        <Form.Item>
                            <Button
                                type="primary"
                                htmlType="submit"
                            >
                                Add room
                            </Button>
                            <Button href = '/admin'>Back to Admin UI</Button>
                        </Form.Item>
                    </Form>
                    
                </div>
            </div>
        </>
    );
};
