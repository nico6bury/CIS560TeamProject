import React from "react";
import { Link } from "react-router-dom";
import styled from "styled-components";
import mainLogo from "../images/mainLogo.jpg";
import { useHistory } from "react-router-dom";

export default function Header({ userName, isLoggedIn, setIsLoggedIn }) {
  document.body.style.margin = 0;
  const history = useHistory();

  const HandleLogoutClick = (e) => {
    setIsLoggedIn(false);
    history.push("/");
  };

  return (
    <PageWrapper>
      <div className="headerMain">
        <img src={mainLogo} className="logo" alt="GURPS Book image"></img>
        <div className="headerTitle">GURPS Loot Random Generator</div>
        <div className="headerSub">
          {isLoggedIn && (
            <div>
              <div>Welcome {userName}</div>
              <Link className="mainLink" to="/">
                <span onClick={HandleLogoutClick}>Logout</span>
              </Link>
            </div>
          )}
          {!isLoggedIn && (
            <div className="links">
              <Link className="mainLink" to="/login">
                Login
              </Link>
              <Link className="mainLink" to="/signup">
                Create Account
              </Link>
            </div>
          )}
        </div>
      </div>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  position: -webkit-sticky;
  position: sticky;
  top: 0;
  padding: 1rem 1.5rem;
  background: var(--darkPurpleColor);
  border-bottom: 5px solid var(--primaryOrangeColor);
  z-index: 999;
  width: 100%;
  margin: 0;
  .headerMain {
    display: flex;
    align-items: center;
    justify-content: space-around;
    flex-direction: row;
    //max-width: 1500px;
    margin: 5 auto;
    width: 100%;
  }
  .headerTitle {
    font-size: 2.5rem;
    color: white;
    text-transform: uppercase;
    letter-spacing: 0.12rem;
  }
  .headerSub {
    display: flex;
    align-items: left;
    flex-direction: column;
    font-size: 1rem;
    color: white;
  }
  .logo {
    height: 50%;
    width: 10%;
  }
  @media screen and (max-width: 500px) {
    .headerMain {
      float: none;
      display: block;
      text-align: left;
    }
    .header-right {
      float: none;
    }
  }

  .links {
    display: flex;
    flex-direction: column;
    margin-bottom: 3px;
  }
`;
