import React, { useState } from "react";
import { Button } from '@mui/material';
import { TextField } from '@mui/material';
import { Box } from '@mui/material';
import { Container } from '@mui/material';
import Stack from '@mui/material/Stack';

function Wanting() {

    const [textValue, setTextValue] = useState("");
    const onTextChange = (e) => setTextValue(e.target.value);
    const handleSubmit = () => console.log("i am click");
    const handleReset = () => setTextValue("something");
    return (
        <>
            <Container>
                <Box
                    component="form"
                    sx={{
                        '& .MuiTextField-root': { m: 1, width: '25ch' },
                    }}
                    noValidate
                    autoComplete="off"
                >
                    <h2>Wanting Input Form</h2>
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

                    <Stack >
                    <Button variant="contained" onClick={handleSubmit}>Submit</Button>
                        {/* <Button variant="contained" onClick={handleReset}>Reset</Button> */}
                    </Stack>
                </Box></Container>
        </>
    )
}

export default Wanting

