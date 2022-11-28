import { Container } from '@mui/material';
import { Input, Button, Box, TextField } from '@mui/material';
import React, { useState } from "react";
import axios from "axios";


export const ImageUpload = () => {
  const [file, setFile] = useState();
  const [textValue, setTextValue] = useState("");
  const onTextChange = (e) => setTextValue(e.target.value);
  const handleSubmit = () => console.log("i am click");
  const handleReset = () => setTextValue("something");
  
  const saveFile = (e) => {
    console.log(e.target.files[0]);
    setFile(e.target.files[0]);
  };

  const uploadFile = async (e) => {
    console.log(file);
    const formData = new FormData();
    formData.append("image", file);
    try {
      const res = await axios.post("https://petfinderapi.azurewebsites.net/api/Wanting", formData);
      
      console.log(res);
    } catch (ex) {
      console.log(ex);
    }
  };

  return (
    <>

      <Box sx={{
        '& .MuiTextField-root': { m: 1.5, width: '25ch' },
      }}>

        <TextField
          onChange={onTextChange}
          value={textValue}
          label={"Name"} //optional
        />
        <TextField
          onChange={onTextChange}
          value={textValue}
          label={"Breed"} //optional
        />
        <TextField
          onChange={onTextChange}
          value={textValue}
          label={"Size"} //optional
        />
        <TextField
          onChange={onTextChange}
          value={textValue}
          label={"Characteristics"} //optional
        />
        <TextField
          onChange={onTextChange}
          value={textValue}
          label={"Description"} //optional
        />
        {/* <Input type="file" onChange={saveFile} /> */}
        <TextField
          name="upload-photo"
          type="file"
          onChange={saveFile}
        />
        <Box sx={{ '& button': { m: 0.5 } }}>

          <Button variant="contained" size="small" onClick={uploadFile} >upload</Button>
          <Button variant="contained" size="small" onClick={handleSubmit}>Submit</Button>
        </Box>
      </Box>
    </>
  );
};