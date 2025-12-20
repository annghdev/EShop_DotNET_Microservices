import { BrowserRouter, Routes, Route } from 'react-router-dom'
import MainLayout from './layouts/MainLayout.tsx'
import HomePage from './pages/HomePage.tsx'
import ProductsPage from './pages/ProductsPage.tsx'
import NotFoundPage from './pages/NotFoundPage.tsx'
import ProductDetailPage from './pages/ProductDetailPage.tsx'
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function App() {

    return (
        <>
            <ToastContainer position="top-right" autoClose={3000} />
            
            <BrowserRouter>
                <Routes>
                    <Route element={<MainLayout />}>
                        <Route path='/' element={<HomePage />} />
                        <Route path='/products' element={<ProductsPage />} />
                        <Route path='/products/:id' element={<ProductDetailPage />} />
                    </Route>

                    <Route path='*' element={<NotFoundPage />} />
                </Routes>
            </BrowserRouter>
        </>
    )
}

export default App
