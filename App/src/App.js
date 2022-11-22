
import './App.css';
import { FileUpload } from './pages/FileUpload';
import Wanting from './pages/Wanting';
import BottomNav from './pages/BottomNav';
import Navbar from './pages/Navbar';
import Sighter from './pages/Sighter';
import Maps from './components/Maps'
import CustomMap from './components/CustomMap';
import { Container } from '@material-ui/core';

function App() {
  return (
    <>
      <Navbar />
      <div className="App">
      {/* <CustomMap /> */}
        {/* <Maps/> */}
        {/* <FileUpload /> */}
        <Sighter/>
        {/* <Wanting/> */}
      </div>
      {/* <Container>
        <div>
          <CustomMap />
        </div>
      </Container> */}
      <BottomNav />
    </>
  );
}

export default App;
