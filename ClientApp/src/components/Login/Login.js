import React, { Component } from 'react';
const axios = require('axios');

export class Login extends Component {
    displayName = Login.name

    constructor() {
        super();
    }
    onSetResult(result, key) {
      localStorage.setItem(key, JSON.stringify(result));
      this.setState({ key: result });
    }
    login() {
        axios.post('/api/account/login', {
            email: 'h@h.com',
            password: 'Asdf1234!'
        })
        .then((response) => {
          console.log(response.data);
          this.onSetResult(response.data, "token")
        })
        .catch((error) => {
            console.log(error);
        });    
    }
    

    render() {
        return (
            <div>
                <h1>LOGIN</h1>


                <button onClick={() => this.login()}>Login</button>
            </div>
        );
    }
}
