
import Navbar
 from "./components/Navbar"
import Home from "./pages/Home"
function App() {

  return (
    <>
      <header>
        <Navbar />
      </header>
       <main className="main-content">
           <Home />
       </main>
     
    </>
  )
}

export default App
