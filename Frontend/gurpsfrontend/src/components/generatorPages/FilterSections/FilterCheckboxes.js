import React from "react";

export default function FilterCheckboxes({ data, setData }) {
  //const [checkedData, setCheckedData] = useState(areaDescriptionData);

  const handleToggle = (e, index) => {
    let item = data[index];
    //item.endusetypecode = 99;
    //console.log(item);
    //item.active = e.target.value;
    item.checked = !item.checked;
    e.target.checked = item.checked;
    e.target.value = item.checked;

    let newState = data
      .slice(0, index)
      .concat(item)
      .concat(data.slice(index + 1));

    setData(newState);
    //handleCheckChange(newState);

    //console.log(checkedData);
  };
  // setState(s => ({ ...s, [target.name]:!s[target.name]}));

  let checkboxes = data.map((item, idx) => {
    let chkstr = "";
    //console.log("ITEM: " + item);
    return (
      <div className="checkboxes">
        <label className="checkboxes">
          <input
            type="checkbox"
            //onClick={(e) => handleToggle(e, idx)}
            //onChange={handleChange}
            key={item.id}
            name={item.name}
            value={item.name}
            checked={item.checked}
            onChange={(e) => handleToggle(e, idx)}
            className="checkboxes"
            readOnly={true}
          />
          {item.name}
        </label>
      </div>
    );
  });
  return <div>{checkboxes}</div>;
}
