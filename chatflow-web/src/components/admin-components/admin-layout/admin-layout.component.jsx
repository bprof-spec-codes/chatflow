import React, { Component } from 'react';
import 'antd/dist/antd.css';
import './admin-layout.styles.css';
import { Layout, Menu, Breadcrumb } from 'antd';
import { TeamOutlined, UserOutlined } from '@ant-design/icons';
import AdminUI from '../admin-ui/admin-ui.component';

const { Header, Content, Footer, Sider } = Layout;
const { SubMenu } = Menu;

class AdminLayout extends Component {
    state = {
        collapsed: false,
    };

    onCollapse = collapsed => {
        console.log(collapsed);
        this.setState({ collapsed });
    };

    render() {
        const { collapsed } = this.state;
        return (
            <Layout style={{ minHeight: '100vh' }}>

                <Sider collapsible collapsed={collapsed} onCollapse={this.onCollapse} className='sider'>
                    <div className="logo" />
                    <Menu defaultSelectedKeys={['1']} mode="inline" className='sider'>
                        <SubMenu key="sub1" icon={<UserOutlined />} title="User Options">
                            <Menu.Item key="1">Add</Menu.Item>
                            <Menu.Item key="2">Search</Menu.Item>
                        </SubMenu>
                        <SubMenu key="sub2" icon={<TeamOutlined />} title="Group Options">
                            <Menu.Item key="3">Add</Menu.Item>
                            <Menu.Item key="4">Search</Menu.Item>
                        </SubMenu>
                    </Menu>
                </Sider>

                <Layout className="site-layout">
                    <Header className="site-layout-background" />
                    <Content style={{ margin: '0 16px' }} className='content-container'>
                        <AdminUI />
                    </Content>
                    <Footer style={{ textAlign: 'center' }}>Ant Design ©2018 Created by Ant UED</Footer>
                </Layout>
            </Layout>
        );
    }
}
export default AdminLayout;