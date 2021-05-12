import React from 'react';
import 'antd/dist/antd.css';
import { Dropdown, Button } from 'antd';
import { DeleteOutlined } from '@ant-design/icons';
import { Settings } from '../pop-up-settings/settings.component';

export const PopUp = (id, roomID) =>{
  return (
    <Dropdown overlay={<Settings id= {id} roomID = {roomID}/>} placement="topRight" arrow>
          <Button shape='circle' icon={<DeleteOutlined />}></Button>
        </Dropdown>
  );
};    
   
