import React from 'react';
import 'antd/dist/antd.css';
import './add-user.style.css'
import { Form, Input, Button, Radio, Select, Cascader, DatePicker, InputNumber, TreeSelect, Switch } from 'antd';

export const AddUser = () => {
    return (
        <>
        <div className="logo-login">ChatFlow</div>
            <div className='form-container'>
                <div className='form-container2'>
                    <Form>
                        <Form.Item label="Name" >
                            <Input className='form-item' />
                        </Form.Item>
                        <Form.Item label="Password">
                            <Input className='form-item' />
                        </Form.Item>
                        <Form.Item label="Select Rank">
                            <Select>
                                <Select.Option value="demo">Admin</Select.Option>
                                <Select.Option value="demo">User</Select.Option>
                            </Select>
                        </Form.Item>
                        <Form.Item>
                            <Button type="primary" htmlType="submit" className='add-form-button'>Add User</Button>
                        </Form.Item>
                    </Form>
                </div>

            </div>

        </>
    );
};