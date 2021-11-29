import React, { useState, useEffect } from "react";
import styled from "styled-components";
import Stat from "./Stat";

export default function StatisticsPage({ userId }) {
  const [isLoaded, setIsLoaded] = useState("");
  const [numberOfTables, setNumberOfTables] = useState();
  const [numberOfItems, setNumberOfItems] = useState();
  const [joinedOn, setJoinedOn] = useState();
  const [numberGenerated, setNumberGenerated] = useState();

  useEffect(() => {
    //doFetch();
    setNumberOfItems("4");
    setNumberOfTables("2");
    setJoinedOn("2021-27-11");
    setNumberGenerated("50");
  }, []);

  const doFetch = () => {
    fetch("http://localhost:5000/api/GetUserInventorySummary", {
      method: "post",
      headers: {
        //"Content-Type": "application/json",
        //"Access-Control-Allow-Credentials": true,
      },
      //credentials: "include",
      body: JSON.stringify({
        requestType: "getUserStatistics",
        userId: userId,
      }),
    })
      .then((res) => res.json())
      .then(
        (result) => {
          console.log(result);
          //If there was an error fetching the data
          setJoinedOn(result.joinedOn);
          setNumberOfTables(result.numberOfTables);
          setNumberOfItems(result.numberOfItems);
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
      <div className="statsWrapper">
        <h3>Statistics</h3>
        <Stat title="Joined On" data={joinedOn} />
        <div className="separaterBottom" />
        <Stat title="Number of Tables Created" data={numberOfTables} />
        <div className="separaterBottom" />
        <Stat title="Number of Items Created" data={numberOfItems} />
        <div className="separaterBottom" />
        <Stat title="Total Number of Items Generated" data={numberGenerated} />
        <div className="separaterBottom" />
      </div>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  .statsWrapper {
    display: flex;
    flex-direction: column;
  }
  .separaterBottom {
    margin-bottom: 5px;
  }
`;
