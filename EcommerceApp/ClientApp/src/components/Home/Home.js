import CategoriesSection from "../Categories/CategoriesSection"
export default function Home({ categories, isActive }) {

    return (
        <CategoriesSection categories={categories} isActive={isActive} />
    );
}
