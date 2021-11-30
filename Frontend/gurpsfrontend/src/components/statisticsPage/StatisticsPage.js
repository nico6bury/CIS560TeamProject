import React, { useState, useEffect } from "react";
import styled from "styled-components";
import CategoryStat from "./CategoryStat";
import Stat from "./Stat";

export default function StatisticsPage({ userId }) {
  const [isLoaded, setIsLoaded] = useState("");
  const [numberOfTables, setNumberOfTables] = useState();
  const [numberOfItems, setNumberOfItems] = useState();
  const [joinedOn, setJoinedOn] = useState();
  const [numberGenerated, setNumberGenerated] = useState();
  const [allCategoryInfo, setAllCategoryInfo] = useState([]);
  const [itemsGenerated, setItemsGenerated] = useState();
  const [tablesUsed, setTablesUsed] = useState("");

  useEffect(() => {
    doCategoryFetch();
    doUserFetch();
  }, []);

  const doCategoryFetch = () => {
    fetch("http://localhost:5000/api/GetItemCategorySummary", {
      method: "get",
      headers: {
        //"Content-Type": "application/json",
        //"Access-Control-Allow-Credentials": true,
      },
    })
      .then((res) => res.json())
      .then(
        (result) => {
          console.log(result);
          setAllCategoryInfo(result);

          //If there was an error fetching the data
          // setJoinedOn(result.joinedOn);
          // setNumberOfTables(result.numberOfTables);
          // setNumberOfItems(result.numberOfItems);
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

  const doUserFetch = () => {
    let send = JSON.stringify({
      UserId: userId,
    });
    fetch(`http://localhost:5000/api/GetUserItemSummary/${send}`, {
      method: "get",
      headers: {
        //"Content-Type": "application/json",
        //"Access-Control-Allow-Credentials": true,
      },
    })
      .then((res) => res.json())
      .then(
        (result) => {
          console.log(result);
          //setAllCategoryInfo(result);
          //If there was an error fetching the data
          setJoinedOn(result.joinedOn);
          setNumberOfTables(result.tablesCreated);
          setNumberOfItems(result.itemsCreated);
          setTablesUsed(result.tablesUsed);
          setItemsGenerated(result.itemsGenerated);
          setIsLoaded("loaded");
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
      {isLoaded === "loaded" && (
        <div className="statsWrapper">
          <h3>User Statistics</h3>
          <Stat title="Joined On" data={joinedOn} />
          <div className="separaterBottom" />
          <Stat title="Number of Tables Created" data={numberOfTables} />
          <div className="separaterBottom" />
          <Stat title="Number of Items Created" data={numberOfItems} />
          <div className="separaterBottom" />
          <Stat
            title="Total Number of Items Generated"
            data={numberGenerated}
          />
          <div className="separaterBottom" />
          <Stat title="Number of Tables Generated From" data={tablesUsed} />
          <div className="separaterBottom" />
          <Stat title="Number of Items Generated" data={itemsGenerated} />
          <div className="separaterBottom" />
          <div className="separaterBottom" />
          <h3>Table Statistics</h3>
          <CategoryStat data={allCategoryInfo} />
          <div className="separaterBottom" />
        </div>
      )}
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
