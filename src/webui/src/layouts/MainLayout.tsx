import { Outlet, Link } from 'react-router-dom'

export default function MainLayout() {
    return (
        <>
            <header>
                <h1>Product Management</h1>
                <nav>
                    <Link to="/">Home</Link> |{" "}
                    <Link to="/products">Products</Link>
                </nav>
                <hr />
            </header>

            <main>
                <Outlet />
            </main>
        </>
    )
}
