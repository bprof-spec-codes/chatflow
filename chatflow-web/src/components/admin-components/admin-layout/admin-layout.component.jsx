import React, { Component } from 'react';
import 'antd/dist/antd.css';
import './admin-layout.styles.css';
import { Layout, Menu } from 'antd';
import { TeamOutlined, UserOutlined } from '@ant-design/icons';
import { CardList } from '../card-list/card-list.component';
import { SearchBox } from '../search-box/search-box.component';
import { Button } from 'antd';
import { DeleteOutlined } from '@ant-design/icons';

const { Content, Footer, Sider } = Layout;
const { SubMenu } = Menu;
const axios = require("axios");



class AdminLayout extends Component {
    
    state = {
        collapsed: false,
    };

    onCollapse = collapsed => {
        console.log(collapsed);
        this.setState({ collapsed });
    };

    constructor() {
        super();

        this.state = {
            members: [],
            groups: [],
            searchUser: '',
            token: '',
            room: '',
        };
    }

    componentDidMount() {

        const minTime = new Promise((resolve) => setTimeout(resolve, 200));
        const minTime2 = new Promise((resolve) => setTimeout(resolve, 1200));
        const req = axios.get(`/auth`);
        const req2 = axios.get(`/room`);


        Promise.all([minTime, req]).then((values) => {
            const reqData = values[1];
            this.setState({ members: reqData.data });
        }
        );

        Promise.all([minTime2, req2]).then((values) => {
            const reqData2 = values[1];
            this.setState({ groups: reqData2.data });
        }
        );
    }
    onClick = (value) => {
        axios
            .delete(`/room/${value}`)
    };

    handleChange = (value) =>{
        this.state.room.setState(value);
    }

    render() {
        const { members, searchUser } = this.state;
        const filteredMembers = members.filter(member =>
            member.userName.toLowerCase().includes(searchUser.toLowerCase())
        );
        const { collapsed } = this.state;
        return (
            <Layout style={{ minHeight: '100vh'}} >
                <Sider collapsible collapsed={collapsed} onCollapse={this.onCollapse} className='sider'>
                    <div className="logo" />
                    <Menu defaultSelectedKeys={['1']} mode="inline" className='sider'>
                        <SubMenu key="sub1" icon={<UserOutlined />} title="User Options">
                            <Menu.Item key="1">
                                <a href='addUser'>Add User to Room</a>
                            </Menu.Item>
                            <Menu.Item key="2">
                                <SearchBox
                                    placeholder='Search User'
                                    handleChange={e => this.setState({ searchUser: e.target.value })}
                                />
                            </Menu.Item>
                        </SubMenu>
                        <SubMenu key="sub2" icon={<TeamOutlined />} title="Room Options">
                            <Menu.Item key="3">
                                <a href='/addRoom'>Add Room</a>
                            </Menu.Item>
                            <Menu.Item key="4">
                                <a href='/exportRoom'>Export Room</a>
                            </Menu.Item>
                            <Menu.Item key="4">
                                <a href='/roomDetail'>Rooms Detail</a>
                            </Menu.Item>
                        </SubMenu>
                        <SubMenu key="sub3" icon={<TeamOutlined />} title="Rooms">
                            {this.state.groups?.map(room => (
                                <Menu.Item key={room.roomID} >
                                    <Button /*onClick={this.onClick(room.roomID)}*/ value={room.roomID} shape='round' icon={<DeleteOutlined />}></Button>
                                    {room.roomName}                                    
                                </Menu.Item>
                            ))}
                        </SubMenu>
                        <Menu.Item key="5">
                                <a href='/'>Exit from Admin UI</a>
                            </Menu.Item>
                    </Menu>
                </Sider>

                <Layout className="site-layout-user">
                    <Content style={{ margin: '0 16px' }} className='content-container'>
                        <div className="logo-login">ChatFlow</div>
                        <div className='search'>
                            <CardList
                                members={filteredMembers}>
                            </CardList>
                        </div>
                    </Content>
                    <Footer style={{ textAlign: 'center' }}>Created by Team Chatflow</Footer>
                </Layout>
            </Layout>



        );
    }
}
export default AdminLayout;