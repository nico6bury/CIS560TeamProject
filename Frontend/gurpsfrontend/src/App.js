import { useState, useEffect } from "react";
import styled from "styled-components";
import { Route, Switch } from "react-router";
import OriginalGeneratorPage from "./components/generatorPages/OriginalGeneratorPage";
import SpicyGeneratorPage from "./components/generatorPages/SpicyGeneratorPage";
import Header from "./components/Header";
import Sidebar from "./components/Sidebar";
import TableInfoPage from "./components/tableInfoPage/TableInfoPage";
import { Fragment } from "react/cjs/react.production.min";
import "./App.css";
import LoginPage from "./components/loginSignUpPages/LoginPage";
import SignUpPage from "./components/loginSignUpPages/SignUpPage";

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [userName, setUserName] = useState("");
  const [userId, setUserId] = useState(null);
  const [isLoaded, setIsLoaded] = useState(null);

  useEffect(() => {
    //fetchUserData();

    //The following is to simulate a call to fetchUserData()
    //setIsLoggedIn(true);
    setIsLoaded("loaded");
    setUserName("sldiener");
  }, [isLoggedIn]);

  const fetchUserData = () => {
    //Do userInfo fetch here and set returned values to state
    fetch("http://localhost:5000/req/userInfo", {
      method: "post",
      headers: {
        //"Content-Type": "application/json",
        //"Access-Control-Allow-Credentials": true,
      },
      //credentials: "include",
      body: JSON.stringify({}),
    })
      .then((res) => res.json())
      .then(
        (result) => {
          console.log(result);
          //If there was an error fetching the data
          if (result.response.apiStatusCode !== "OK") {
            setIsLoaded("error");
            setIsLoggedIn(false);
            return;
          }
          //If the user is not logged in
          if (result.response.data.loggedIn === 0) {
            setIsLoggedIn(false);
            //setIsLoaded("incorrect");
            return;
          }
          //The user is logged in
          if (result.response.data.loggedIn === 1) {
            setIsLoggedIn(true);
            setUserId(result.response.data.dealerid);
            setUserName(result.response.data.dealerName);
            setIsLoaded("loaded");
          }
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        (error) => {
          setIsLoaded("error");
          //console.log(error);
        }
      );
  };

  return (
    <PageWrapper>
      <div>
        <Header
          userName={userName}
          isLoggedIn={isLoggedIn}
          setIsLoggedIn={setIsLoggedIn}
        />
        <div className="contentWrapper">
          <Sidebar isLoggedIn={isLoggedIn} />
          <Switch>
            <Route exact path="/" component={OriginalGeneratorPage} />
            <Route
              path="/login"
              render={(props) => <LoginPage setIsLoggedIn={setIsLoggedIn} />}
            />
            <Route
              path="signup"
              render={(props) => <SignUpPage setIsLoggedIn={setIsLoggedIn} />}
            />
            {isLoggedIn && (
              <Fragment>
                <Route path="/spicygenerator" component={SpicyGeneratorPage} />
                <Route path="/tableinfo" component={TableInfoPage} />
              </Fragment>
            )}
          </Switch>
        </div>
      </div>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  display: flex;

  .contentWrapper {
    display: flex;
    flex-direction: row;
    align-items: left;
  }
`;

const LoginPageWrapper = styled.nav`
  display: flex !important;
  align-items: center !important;
  justify-content: center !important;
  flex-direction: column;
  text-align: center;
  width: 100%;
  height: 100%;
  flex-grow: 1;
  color: red;
`;

export default App;
