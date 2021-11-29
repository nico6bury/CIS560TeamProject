import React, { useState, useEffect } from "react";
import styled from "styled-components";
import UserTable from "./UserTable";

let fakeUserData = [
  {
    table: "swords",
    creatingUser: "User1",
    data: [
      {
        name: "wooden sword",
        id: 1,
        basePrice: "34.5",
      },
      {
        name: "metal sword",
        id: 2,
        basePrice: "100.4",
      },
    ],
  },
  {
    table: "animals",
    creatingUser: "User2",
    data: [
      {
        name: "flamingo",
        id: 1,
        basePrice: "5.00",
      },
      {
        name: "tiger",
        id: 2,
        basePrice: "6.89",
      },
    ],
  },
];

export default function TableInfoPage() {
  const [userTables, setUserTables] = useState(fakeUserData);
  const [isLoaded, setIsLoaded] = useState("");

  useEffect(() => {
    //doFetch();
  }, []);

  const doFetch = () => {
    fetch("http://localhost:5000/api/RetrieveAllItems", {
      method: "post",
      headers: {
        "Content-Type": "application/json",
        "Access-Control-Allow-Credentials": true,
      },
      //credentials: "include",
      body: JSON.stringify({
        username: "getUserDefinedTables",
      }),
    })
      .then((res) => res.json())
      .then(
        (result) => {
          console.log(result);
          //If there was an error fetching the data
          setUserTables(result);
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

  const Tables = () => {
    let toReturn = userTables.map((item) => {
      return (
        <div>
          <div>
            <b>
              {item.table} - {item.creatingUser}
            </b>
          </div>
          <div className="tableWrap">
            <UserTable data={item.data} />
          </div>
        </div>
      );
    });
    return <div>{toReturn}</div>;
  };

  return (
    <PageWrapper>
      <h1>User-Defined Tables</h1>
      <Tables />
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  .tableWrap {
    display: flex;
    margin-right: 20px;
  }
`;
