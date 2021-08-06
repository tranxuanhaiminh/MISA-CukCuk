<template>
    <div class="header">
        <span class="header-left">
            <div class="sidebar"></div>
            <div class="logo"></div>
        </span>
        <div class="header-right">
            <div class="header-right-menu">
                <select class="header-right-menu-select text-labelfieldinput">
                    <option value="BienDong">Nhà hàng Biển Đông</option>
                </select>
            </div>
            <div class="user">
                <div class="user-option"></div>
                <div class="text-label">Nguyễn Văn Mạnh</div>
                <div class="user-icon"></div>
            </div>
        </div>
    </div>
</template>

<style lang="css" scoped src='../../css/layout/header.css'></style>
<script>
export default {

    name:"the-header"
}
</script>