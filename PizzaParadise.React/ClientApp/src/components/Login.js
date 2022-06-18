import React, { Component } from 'react';

export class Login extends Component {
    static displayName = Login.name;

    constructor(props) {
        super(props);
        this.state = {
            emailAddress: "",
            password: ""
        };

        this.login = this.login.bind(this);
        this.handleEmailAddressChange = this.handleEmailAddressChange.bind(this);
        this.handlePasswordChange = this.handlePasswordChange.bind(this);
    }

    async login(e) {

        e.preventDefault();
        console.log("Login");

        const response = await fetch("accounts");
        const data = await response.json();
    }

    handleEmailAddressChange(e) {
        this.setState({ emailAddress: e.target.value });
    }

    handlePasswordChange(e) {
        this.setState({ password: e.target.value });
    }

    render() {
        return (
            <div>
                <form onSubmit={this.login}>
                    <div className="card">
                        <h5 className="card-header">
                            Login
                        </h5>
                        <div className="card-body">
                            <label>Email Address</label>
                            <input type="text" value={this.state.emailAddress} onChange={this.handleEmailAddressChange} className="form-control" />
                            <label>Password</label>
                            <input type="text" value={this.state.password} onChange={this.handlePasswordChange} className="form-control" />
                            <button type="submit" className="btn btn-primary mt-3">Login</button>
                        </div>
                    </div>
                </form>
            </div>
        );
    }
}
