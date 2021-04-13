import { CardList } from '../card-list/card-list.component';
import React, { Component } from 'react';
import './admin-ui.style.css';

class AdminUI extends Component {
  constructor() {
    super();

    this.state = {
      members: [],
      searchField: ''
    };
  }

  componentDidMount() {
    fetch('https://jsonplaceholder.typicode.com/users')
      .then(response => response.json())
      .then(users => this.setState({ members: users }));
  }

  render() {
    return (
      <div className="AdminUI">
        <div className='tools'>
          <CardList
            members={this.state.members}>
          </CardList>

          <input
            type='search'
            placeholder='search user'
            onChange={e => {
              this.setState({ searchField: e.target.value }, () => console.log(this.state));
            }} />
        </div>


      </div >
    );
  }

}

export default AdminUI;
