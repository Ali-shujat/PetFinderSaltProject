import './App.css';
import Map from "./Components/MapComponent/MapComponent";
import Frontpage from "./Pages/Frontpage/Frontpage";
import Navbar from "./Components/Navbar/Navbar";
import Container from '@mui/material/Container';
import { createTheme } from '@mui/material/styles';
import { ThemeProvider } from '@emotion/react';
import { Route, Routes } from "react-router-dom";


function App() {

  // Temporary test values
  const kattTheme = createTheme({
    palette: {
      primary: {
        light: '#e2a2b4',
        main: '#c44569',
        dark: '#622335',
        contrastText: '#fff5e2',

      },
      secondary: {
        light: '#ff7961',
        main: '#f44336',
        dark: '#ba000d',
        contrastText: '#000',
      },
    },
  });


  return (
    <ThemeProvider theme={kattTheme}>

      <Container maxWidth="lg">
        <Navbar />

        <main id="ContentArea">
          <Routes>
            <Route path="" element={<Frontpage />} />
            <Route path="/" element={<Frontpage />} />
            <Route path="/reportsighting" element={<Frontpage />} />
            <Route path="/map" element={<Map />} />
            <Route path="/login" element={<Frontpage />} />
            <Route path="/about" element={<Frontpage />} />
          </Routes>
        </main>

        <footer>
          Footer
        </footer>
      </Container>

    </ThemeProvider>
  );
}

export default App;
