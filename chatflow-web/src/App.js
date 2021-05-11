import React from "react";
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Redirect,
} from "react-router-dom";
import { NormalLoginForm } from "./components/login/login.component";
import { Home } from "./components/home/home.component";
import AdminUI from "./components/admin-components/admin-ui/admin-ui.component";
import AdminLayout from "./components/admin-components/admin-layout/admin-layout.component";
import Cookies from "js-cookie";

const axios = require("axios").default;

const ProtectedRoute = ({ component: Component, ...rest }) => {
  const token = Cookies.get("auth");
  if (token) {
    // TODO axios set global authorization header
    axios.defaults.headers.common["Authorization"] = "Bearer " + token;
    return (
      <Route {...rest} render={(props) => <Component {...rest} {...props} />} />
    );
  }
  return <Redirect to="/login" />;
};

function App() {
  return (
    <Router>
      <Switch>
        <Route path="/login">
          <NormalLoginForm />
        </Route>
        <ProtectedRoute path="/admin" component={AdminLayout} />

        <ProtectedRoute path="/room/:id" component={Home} />

        <ProtectedRoute path="/" component={Home} />
      </Switch>
    </Router>
  );
}

export default App;
