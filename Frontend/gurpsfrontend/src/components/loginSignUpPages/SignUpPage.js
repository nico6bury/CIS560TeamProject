import React, { useState } from "react";
import styled from "styled-components";
import { useHistory } from "react-router-dom";

export default function SignUpPage({ setIsLoggedIn }) {
  const [username, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const [isLoaded, setIsLoaded] = useState("");
  const history = useHistory();

  const handleSubmit = (e) => {
    e.preventDefault();
    //If the user hasn't entered anything in the boxes, just return
    if (username.length < 1 || password.length < 8) {
      setIsLoaded("incorrect");
      return;
    }
    //The following will attempt to log the user in
    doFetch();

    //The following is for testing purposes and is to simulate a call to the backend to log the user in
    //setIsLoaded("incorrect");
    history.push("/");
    //setIsLoggedIn(true);
  };

  //Procedure or function 'CreateUser' expects parameter '@Username', which was not supplied.'

  const doFetch = () => {
    fetch("http://localhost:5000/api/CreateUser", {
      method: "post",
      headers: {
        "Content-Type": "application/json",
        "Access-Control-Allow-Credentials": true,
      },

      body: JSON.stringify({
        username: username,
        password: password,
        //Send username and password
      }),
    })
      .then((res) => res.json())
      .then(
        (result) => {
          console.log(result);
          setIsLoggedIn(true);
          setIsLoaded("loaded");
          //If error
          // if (result.response.apiStatusCode !== "OK") {
          //   setIsLoaded("error");
          //   //return;
          // }
          // //The sign up succeeded! Yay!
          // else {
          //   setIsLoggedIn(true);
          //   setIsLoaded("loaded");
          // }
          //The user is logged in
          //setIsLoggedIn(true);
          //console.log(result);
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        (error) => {
          setIsLoaded("error");
          console.log(error);
        }
      );
  };

  return (
    <PageWrapper>
      <form className="formWrapper">
        <div className="loginLabel">GURPS Random Generator Sign Up</div>
        <div className="inputDiv">
          {/* <p>Username</p> */}
          <input
            type="text"
            placeholder="username"
            onChange={(e) => setUserName(e.target.value)}
          />
        </div>
        <div className="inputDiv">
          {/* <p>Password</p> */}
          <input
            type="password"
            placeholder="password"
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <div>
          <button className="mainBtn" onClick={handleSubmit}>
            Sign up!
          </button>
        </div>
        {isLoaded === "error" && (
          <div className="errorMessage">Error signing up.</div>
        )}
        {isLoaded === "incorrect" && (
          <div className="errorMessage">
            Please make sure your password is at least 8 characters.
          </div>
        )}
      </form>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  /* .formWrapper {
    display: flex !important;
    justify-content: center !important;
    height: 100% !important;
    width: 100% !important;
    flex-direction: column;
    flex: 2;
    align-items: stretch;
    flex-grow: 1;
  } */
  .inputDiv {
    margin-bottom: 5px;
  }
  .loginLabel {
    font-size: 1.8rem;
    font-weight: 400;
    line-height: 1.5;
    color: var(--mainBlack);
  }
`;
