import React from 'react';
import 'antd/dist/antd.css';
import { Menu, Dropdown, Button } from 'antd';
import { SettingFilled } from '@ant-design/icons';
import { Settings } from '../pop-up-settings/settings.component';

export const PopUp = () =>{
  <Menu>
    <Menu.Item>
      <a target="_blank" rel="noopener noreferrer" href="https://www.antgroup.com">
        1st menu item
      </a>
    </Menu.Item>
    <Menu.Item>
      <a target="_blank" rel="noopener noreferrer" href="https://www.aliyun.com">
        2nd menu item
      </a>
    </Menu.Item>
    <Menu.Item>
      <a target="_blank" rel="noopener noreferrer" href="https://www.luohanacademy.com">
        3rd menu item
      </a>
    </Menu.Item>
  </Menu>

  return (
    <Dropdown overlay={<Settings/>} placement="topLeft" arrow>
          <Button icon={<SettingFilled/>}></Button>
        </Dropdown>
  );
};    
   
