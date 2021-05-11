import React, { Component } from 'react';
import 'antd/dist/antd.css';
import './admin-layout.styles.css';
import { Layout, Menu } from 'antd';
import { TeamOutlined, UserOutlined } from '@ant-design/icons';
import { CardList } from '../card-list/card-list.component';
import { SearchBox } from '../search-box/search-box.component';
import axios from 'axios'

const { Header, Content, Footer, Sider } = Layout;
const { SubMenu } = Menu;
const api = axios.create({
    baseURL: 'https://localhost:5000'
})

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
        };
        



    }

    componentDidMount() {
        /*fetch('https://localhost:44325/auth/')
            .then(response => response.json())
            .then(users => this.setState({ members: users }));*/
        api.get(`/auth/login`,
            {
                userName : 'admin',
                password : 'admin'
            })
            .then(response => console.log(response)).catch((error) => {
                console.log(error.message);
              });
            /*.then(getToken => this.setState({ token: getToken }))
            .then(
                api.get('/auth',{ 'Authorization': `Bearer ${this.state.token}` })
                    .then(response => response.json())
                    .then(users => this.setState({ members: users })
                    )
            )*/
    }

    render() {
        const { members, searchUser } = this.state;
        const filteredMembers = members.filter(member =>
            member.userName.toLowerCase().includes(searchUser.toLowerCase())
        );
        const { collapsed } = this.state;
        return (
            <Layout style={{ minHeight: '100vh' }}>

                <Sider collapsible collapsed={collapsed} onCollapse={this.onCollapse} className='sider'>
                    <div className="logo" />
                    <Menu defaultSelectedKeys={['1']} mode="inline" className='sider'>
                        <SubMenu key="sub1" icon={<UserOutlined />} title="User Options">
                            <Menu.Item key="1">Add</Menu.Item>
                            <Menu.Item key="2">
                                <SearchBox
                                    placeholder='Search User'
                                    handleChange={e => this.setState({ searchUser: e.target.value })}
                                />
                            </Menu.Item>
                        </SubMenu>
                        <SubMenu key="sub2" icon={<TeamOutlined />} title="Group Options">
                            <Menu.Item key="3">Add</Menu.Item>
                        </SubMenu>
                    </Menu>
                </Sider>

                <Layout className="site-layout-user">
                    <Header className="site-layout-background" />
                    <Content style={{ margin: '0 16px' }} className='content-container'>
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