import React, { useState, useEffect } from "react";
import styled from "styled-components";
import GenerateBox from "./GenerateBox";
import Filters from "./Filters";

let fakeICD = [
  {
    name: "Fibers and Fabrics",
    itemCategoryId: 1,
    checked: true,
  },
  {
    name: "Spices",
    itemCategoryId: 2,
    checked: true,
  },
  {
    name: "Jewelry",
    itemCategoryId: 3,
    checked: false,
  },
];

let declaredExtrasData = [
  {
    name: "Embelishments",
    id: 1,
    checked: true,
  },
  {
    name: "Enchantments",
    id: 2,
    checkd: true,
  },
];

let fakeUserDefinedTables = [
  {
    name: "Swords",
    id: 60,
    checked: true,
  },
  {
    name: "animals",
    id: 61,
    checked: false,
  },
];

export default function SpicyGeneratorPage() {
  const [itemCategoryData, setItemCategoryData] = useState(fakeICD);
  const [extrasData, setExtrasData] = useState(declaredExtrasData);
  const [tablesToInclude, setTablesToInclude] = useState();
  const [itemCategoryUDData, setItemCategoryUDData] = useState(
    fakeUserDefinedTables
  );
  const [isLoaded, setIsLoaded] = useState("");

  useEffect(() => {
    //fetch the itemCategory data and spicyCategory data
    //doFetch();
  });

  const doFetch = () => {
    fetch("http://localhost:5000", {
      method: "post",
      headers: {
        //"Content-Type": "application/json",
        //"Access-Control-Allow-Credentials": true,
      },
      //credentials: "include",
      body: JSON.stringify({
        typeRequest: "getAllItemCategoryData",
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

          setIsLoaded("loaded");
          setItemCategoryData(mapDataToCheckboxes(result.originalData));
          setItemCategoryUDData(mapDataToCheckboxes(result.spicyData));
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

  const mapDataToCheckboxes = (data) => {
    let finishedArray = [];
    data.map((item) => {
      let curItem = {
        name: item.name,
        id: item.id,
        checked: true,
      };
      finishedArray.push(curItem);
    });
    return finishedArray;
  };

  return (
    <PageWrapper>
      <h1>GURPS Generator With User-Defined Tables</h1>
      <div className="pageContent">
        <GenerateBox
          typeBox="Spicy"
          originalData={itemCategoryData}
          spicyData={itemCategoryUDData}
        />
        <div className="spacer1" />
        <Filters
          itemCategoryData={itemCategoryData}
          setItemCategoryData={setItemCategoryData}
          extrasData={extrasData}
          setExtrasData={setExtrasData}
          isSpicy={true}
          userTables={itemCategoryUDData}
          setUserTables={setItemCategoryUDData}
        ></Filters>
      </div>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  display: flex;
  flex-direction: column;

  .pageContent {
    display: flex;
    flex-direction: row;
  }
  .spacer1 {
    margin-right: 100px;
  }
`;
