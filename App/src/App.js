
import './App.css';
import { FileUpload } from './pages/FileUpload';
import Wanting from './pages/Wanting';
import BottomNav from './pages/BottomNav';
import Navbar from './pages/Navbar';
import Sighter from './pages/Sighter';
import CustomMap from './components/CustomMap';
import { Container } from '@material-ui/core';
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
    <>
      <ThemeProvider theme={kattTheme}>

        <Container maxWidth="lg">
          <Navbar />

          <main id="ContentArea">
            <Routes>
              <Route path="" element={<Wanting />} />
              <Route path="/" element={<Wanting />} />
              <Route path="/reportsighting" element={<FileUpload />} />
              <Route path="/map" element={<CustomMap />} />
              <Route path="/login" element={<Sighter />} />
              <Route path="/about" element={<Wanting />} />
            </Routes>
          </main>

          {/* <footer>
            Footer
          </footer> */}
        </Container>
        <BottomNav></BottomNav>
      </ThemeProvider>
    </>
  );
}

export default App;
