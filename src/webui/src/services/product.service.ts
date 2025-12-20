import { apiClient } from "./api.client";
import type { Product } from "../models/product";

// export const productService = {
//     async getAll(): Promise<Product[]> 
//     {
//         const response = await apiClient.get('/products');
//         return response.data;
//     },

//     // getAll(): Promise<Product[]> {
//     //     console.log("Fetching all products...");
//     //     return apiClient.get('products').then(r => r.data);
//     // },

//     async getById(id: string): Promise<Product> {
//         const response = await apiClient.get(`/products/${id}`);
//         return response.data;
//     },

//     async create(product: Product): Promise<string> {
//         const response = await apiClient.post("/products", product);
//         return response.data;
//     },

//     update(product: Product): Promise<void> {
//         return apiClient.put(`/products/${product.id}`, product);
//     },

//     delete(id: string): Promise<void> {
//         return apiClient.delete(`/products/${id}`);
//     }
// }

export const productService = {
    getAll(): Promise<Product[]> {
        return apiClient.get('/products').then(r => r.data);
    },

    getById(id: string): Promise<Product> {
        return apiClient.get(`/products/${id}`).then(r => r.data);
    },

    create(product: Product): Promise<string> {
        return apiClient.post('/products', product).then(r => r.data);
    },

    update(product: Product): Promise<void> {
        return apiClient.put(`/products/${product.id}`, product);
    },

    delete(id: string): Promise<void> {
        return apiClient.delete(`/products/${id}`);
    }
}