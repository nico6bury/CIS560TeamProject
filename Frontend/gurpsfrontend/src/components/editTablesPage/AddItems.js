import React, { useState, useEffect } from "react";
import styled from "styled-components";
import CreateTable from "./CreateTable";
import DisplayAndEditTables from "./DisplayAndEditTables";

let starterData = {
  name: "",
  unitPrice: "",
  baseWeight: "",
  weightType: "",
  quantityMin: "",
  quantityMax: "",
  description: "",
  relativeChance: "",
};

export default function AddItems({ tables }) {
  const [tableData, setTableData] = useState("");
  const [addIsClicked, setAddIsClicked] = useState(false);
  const [newItemData, setNewItemData] = useState(starterData);
  const [goIsClicked, setGoIsClicked] = useState(false);
  const [tableValue, setTableValue] = useState("");
  const [addItemTableId, setAddItemTableId] = useState(-1);
  const [isLoaded, setIsLoaded] = useState("");

  useEffect(() => {
    setTableData(AddCheckedProperty(tables));
  }, []);

  const AddCheckedProperty = (tables) => {
    let finishedArray = [];
    tables.map((item) => {
      let curItem = {
        name: item.table,
        id: item.id,
        checked: false,
      };
      //console.log(curItem.name);
      finishedArray.push(curItem);
    });
    return finishedArray;
  };

  const handleNewItemClick = (e) => {
    e.preventDefault();
    setAddIsClicked(true);
  };

  const getIdOfTable = () => {
    var radioButtons = document.getElementsByName("tableRadioOptions");
    for (var i = 0; i < radioButtons.length; i++) {
      if (radioButtons[i].checked == true) {
        setAddItemTableId(radioButtons[i].id);
      }
    }
  };

  const TablesCheckboxes = () => {
    // setState(s => ({ ...s, [target.name]:!s[target.name]}));

    let checkboxes = tableData.map((item, idx) => {
      let chkstr = "";
      //console.log("ITEM: " + item.name);
      return (
        <div className="checkboxes">
          <input
            type="radio"
            //onClick={(e) => handleToggle(e, idx)}
            //onChange={handleChange}
            key={item.id}
            id={item.id}
            name={"tableRadioOptions"}
            value={item.name}
            //checked={tableValue}
            //onChange={(e) => handleToggle(e, idx)}
            className="checkboxes"
            //readOnly={true}
          />
          <label className="checkboxes" for={item.id}>
            {item.name}
          </label>
        </div>
      );
    });
    return <div>{checkboxes}</div>;
  };

  const handleInputChange = (e) => {
    setNewItemData({
      ...newItemData,
      [e.target.name]: e.target.value,
    });
  };

  const handleNewItemAddClick = (e) => {
    e.preventDefault();
    //console.log(e.target);
    setGoIsClicked(false);
    //doAddFetch();
  };

  const doAddFetch = () => {
    //Do userInfo fetch here and set returned values to state
    fetch("http://localhost:5000", {
      method: "post",
      headers: {
        //"Content-Type": "application/json",
        //"Access-Control-Allow-Credentials": true,
      },
      //credentials: "include",
      body: JSON.stringify({
        requestType: "sendAddNewItem",
        addToTable: addItemTableId,
        data: newItemData,
      }),
    })
      .then((res) => res.json())
      .then(
        (result) => {
          console.log(result);
          //If there was an error fetching the data
          if (result.response.apiStatusCode !== "OK") {
            setIsLoaded("errorAddItem");
            return;
          } else {
            setIsLoaded("successAddItem");
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

  const handleGoClick = (e) => {
    e.preventDefault();
    setGoIsClicked(true);
    setAddIsClicked(false);
    getIdOfTable();
  };

  return (
    <PageWrapper>
      <div>
        {!goIsClicked && (
          <button className="mainBtn" onClick={handleNewItemClick}>
            Add New Item
          </button>
        )}

        {addIsClicked && (
          <div>
            <div>Please select the table to add an item to.</div>
            <TablesCheckboxes />
            <button className="mainBtn" onClick={handleGoClick}>
              Go!
            </button>
          </div>
        )}
        {goIsClicked && (
          <div>
            <form className="addNewItemForm">
              <input
                className="formInput separaterBottom2"
                name="itemNameInput"
                placeholder="Item Name"
                size="12"
                maxLength={20}
                onChange={handleInputChange}
              />
              <input
                className="formInput separaterBottom2"
                name="unitPriceInput"
                placeholder="Item Unit Price"
                size="12"
                maxLength={20}
                onChange={handleInputChange}
              />
              <input
                className="formInput separaterBottom2"
                name="baseWeightInput"
                placeholder="Item Base Weight"
                size="12"
                maxLength={20}
                onChange={handleInputChange}
              />
              <input
                className="formInput separaterBottom2"
                name="weightTypeInput"
                placeholder="Item Weight Type"
                size="12"
                maxLength={20}
                onChange={handleInputChange}
              />
              <input
                className="formInput separaterBottom2"
                name="quantityMinInput"
                placeholder="Item Quantity Min"
                size="12"
                maxLength={20}
                onChange={handleInputChange}
              />
              <input
                className="formInput separaterBottom2"
                name="quantityMaxInput"
                placeholder="Item Quantity Max"
                size="12"
                maxLength={20}
                onChange={handleInputChange}
              />
              <input
                className="formInput separaterBottom2"
                name="descriptionInput"
                placeholder="Item Description"
                size="20"
                maxLength={20}
                onChange={handleInputChange}
              />
              <input
                className="formInput separaterBottom2"
                name="relativeChanceInput"
                placeholder="Item Relative Chance"
                size="20"
                maxLength={20}
                onChange={handleInputChange}
              />
              <button className="mainBtn" onClick={handleNewItemAddClick}>
                Add
              </button>
            </form>
          </div>
        )}
        {isLoaded === "errorAddItem" && (
          <div className="errorMessage">Error creating item.</div>
        )}
        {isLoaded === "successAddItem" && (
          <div className="successMessage">
            Successfully added item to table.
          </div>
        )}
      </div>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  .separaterBottom {
    margin-bottom: 20px;
  }
  .addNewItemForm {
    display: flex;
    flex-direction: column;
  }
  .separaterBottom2 {
    margin-bottom: 5px;
  }
`;
