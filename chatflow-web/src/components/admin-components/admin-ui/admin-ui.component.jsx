import { CardList } from '../card-list/card-list.component';
import React, { Component } from 'react';

class AdminUI extends Component {
  constructor() {
    super(); 

    this.state = {
      members: [],
      searchField: ''
    };
  }

  componentDidMount()
  {
    fetch('https://jsonplaceholder.typicode.com/users')
      .then(response => response.json())
      .then(users => this.setState({ members: users }));
  }

  render() {
    return (
      <div className="AdminUI">
        <input
          type='search'
          placeholder='search user' 
          onChange={e => {
            this.setState({ searchField: e.target.value }, () => console.log(this.state));
          }} />
          <CardList
          members={this.state.members}>
        </CardList>        
      </div >
    );
  }

}

export default AdminUI;
