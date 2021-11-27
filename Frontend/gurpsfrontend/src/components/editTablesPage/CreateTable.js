import React, { useState } from "react";
import styled from "styled-components";

let starterData = {
  tableName: "",
};

export default function EditTablesPage({ userId }) {
  const [isClicked, setIsClicked] = useState(false);
  const [inputData, setInputData] = useState(starterData);
  const [isLoaded, setIsLoaded] = useState("");

  const handleCreateClick = (e) => {
    setIsClicked(true);
  };

  const handleInputChange = (e) => {
    setInputData({
      ...inputData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmitClick = (e) => {
    setIsClicked(false);
    //doFetch();
    setIsLoaded("success");
  };

  const doFetch = () => {
    //Do userInfo fetch here and set returned values to state
    fetch("http://localhost:5000", {
      method: "post",
      headers: {
        //"Content-Type": "application/json",
        //"Access-Control-Allow-Credentials": true,
      },
      //credentials: "include",
      body: JSON.stringify({
        typeRequest: "sendNewTable",
        tableName: inputData.tableName,
        userId: userId,
      }),
    })
      .then((res) => res.json())
      .then(
        (result) => {
          console.log(result);
          //If there was an error fetching the data
          if (result.response.apiStatusCode !== "OK") {
            setIsLoaded("error");
            return;
          }
          setIsLoaded("success");
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
      <button className="mainBtn" onClick={handleCreateClick}>
        Create New Table
      </button>
      <div className="separaterBottom" />
      {isClicked && (
        <div className="newAndErrorWrap">
          <div className="newTableNameWrap">
            <input
              className="textInput"
              name="itemCategory"
              placeholder="Item Table Name"
              size="20"
              maxLength="40"
              onChange={handleInputChange}
            />
            <div className="spacer" />
            <button className="mainBtn" onClick={handleSubmitClick}>
              Submit New Table
            </button>
          </div>
        </div>
      )}
      {isLoaded === "error" && (
        <div className="errorMessage">Something went wrong.</div>
      )}
      {isLoaded === "success" && (
        <div className="successMessage">
          Successfully created new table. Please refresh the page to view and
          add data.
        </div>
      )}
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  .spacer {
    margin-right: 10px;
  }
  .newTableNameWrap {
    display: flex;
    flex-direction: row;
  }
  .newAndErrorWrap {
    display: flex;
    flex-direction: column;
  }
  .separaterBottom {
    margin-bottom: 10px;
  }
`;
