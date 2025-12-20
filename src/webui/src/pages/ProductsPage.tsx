import { useNavigate } from 'react-router-dom'
import type { Product } from '../models/product'
import { productService } from '../services/product.service'
import { useEffect, useState } from 'react'
import { toast } from "react-toastify";

export default function ProductsPage() {
    const navigate = useNavigate();

    const [products, setProducts] = useState<Product[]>([])

    useEffect(() => {
        const loadProducts = async () => {
            try {
                const data = await productService.getAll();
                setProducts(data);
            } catch (error: any) {
                toast.error(
                    error.response?.data?.message ?? "Không tải được sản phẩm",
                    { toastId: 'products-load-error' }
                );
            }
        };

        loadProducts();
    }, []);

    return (
        <>
            <h2>Products Page</h2>

            {products.map(p => (
                <p key={p.id}>{p.name} {p.price} <button onClick={() => navigate(`/products/${p.id}`)}>Details</button></p>
            ))}
        </>
    )
}