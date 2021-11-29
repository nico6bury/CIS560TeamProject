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

export default function OriginalGeneratorPage() {
  const [itemCategoryData, setItemCategoryData] = useState(fakeICD);
  const [extrasData, setExtrasData] = useState(declaredExtrasData);
  const [isLoaded, setIsLoaded] = useState("");

  useEffect(() => {
    //fetch the itemCategoryData
    //doFetch();
  }, []);

  const doFetch = () => {
    fetch("http://localhost:5000/api/RetrieveDefaultItemCategories", {
      method: "post",
      headers: {
        "Content-Type": "application/json",
        "Access-Control-Allow-Credentials": true,
      },
      //credentials: "include",
      body: JSON.stringify({}),
    })
      .then((res) => res.json())
      .then(
        (result) => {
          console.log(result);
          //If there was an error fetching the data

          setIsLoaded("loaded");
          setItemCategoryData(mapDataToCheckboxes(result));
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
      <h1>Original GURPS Generator</h1>
      <div className="pageContent">
        <GenerateBox
          typeBox="Original"
          originalData={itemCategoryData}
          spicyData={""}
        />
        <div className="spacer1" />
        <Filters
          itemCategoryData={itemCategoryData}
          setItemCategoryData={setItemCategoryData}
          extrasData={extrasData}
          setExtrasData={setExtrasData}
          isSpicy={false}
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
