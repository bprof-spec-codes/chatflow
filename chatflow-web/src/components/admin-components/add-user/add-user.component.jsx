import React, { useEffect, useState } from "react";
import 'antd/dist/antd.css';
import './add-user.style.css'
import { Form, Button, Select } from 'antd';

export const AddUser = () => {
    const [users, setUser] = useState(null);
    const [rooms, setRoom] = useState(null);
    const axios = require("axios");
    const onFinish = (values) => {
        axios
            .post("/auth/{user.id}/{room.roomID}")
    };


    useEffect(() => {

        const minTime = new Promise((resolve) => setTimeout(resolve, 200));
        const req = axios.get(`/auth`);

        Promise.all([minTime, req]).then((values) => {
            const reqData = values[1];
            console.log(reqData.data);
            setUser(reqData.data);
        }
        );
    }, [axios, setUser]);

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
                        <Form.Item label="Select User">
                            <Select>
                                {users?.map(user => (
                                    <Select.Option value={user.id}>{user.userName}</Select.Option>
                                ))}
                            </Select>
                        </Form.Item>
                        <Form.Item label="Select Room">
                            <Select>
                                {rooms?.map(room => (
                                    <Select.Option value={room.roomID}>{room.roomName}</Select.Option>
                                ))}
                            </Select>
                        </Form.Item>
                        <Form.Item>
                            <Button onClick='' type="primary" htmlType="submit" className='add-form-button'>Add User</Button>
                            <Button className='add-form-button' href = '/admin'>Back to Admin UI</Button>
                        </Form.Item>
                    </Form>
                </div>
            </div>
        </>
    );
};
